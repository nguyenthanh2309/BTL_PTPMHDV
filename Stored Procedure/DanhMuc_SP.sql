use QuanLyNoiThat
go

create proc sp_get_danh_muc_by_id @id int
as
	begin
		select * from DanhMuc where ID = @id
	end
go

create proc sp_get_all_danh_muc
as
	begin	
		select * from DanhMuc
	end
go

create proc sp_create_danh_muc @tendanhmuc nvarchar(max)
as
	begin	
		insert into DanhMuc values(@tendanhmuc)
	end
go

create proc sp_update_danh_muc @id int, @tendanhmuc nvarchar(max)
as
	begin	
		update DanhMuc
		set TenDanhMuc = @tendanhmuc
		where ID = @id
	end
go

create proc sp_update_multiple @json nvarchar(max)
as
	begin
		if(@json is not null)
		begin
			select
					JSON_VALUE(ListToEdit.value,'$.id') as ID,
					JSON_VALUE(ListToEdit.value, '$.tenDanhMuc') as TenDanhMuc
				into #ListToEdit
			from OPENJSON(@json) as ListToEdit
			update DanhMuc
			set DanhMuc.TenDanhMuc = #ListToEdit.TenDanhMuc from #ListToEdit
			where DanhMuc.ID = #ListToEdit.ID
		end
	end
go	

create proc sp_delete_danh_muc @id int
as
	begin	
		delete from DanhMuc where ID = @id
	end
go