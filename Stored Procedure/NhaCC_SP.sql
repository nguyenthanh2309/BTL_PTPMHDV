use QuanLyNoiThat
go

create proc sp_get_nhacc_by_id @id int
as
	begin
		select * from NhaCC where ID = @id
	end
go

create proc sp_get_all_nhacc
as
	begin	
		select * from NhaCC
	end
go

create proc sp_create_nhacc
@tendanhmuc nvarchar(max),
@sdt nvarchar(12),
@diachi nvarchar(max),
@email nvarchar(max)
as
	begin	
		insert into NhaCC values(@tendanhmuc, @sdt, @diachi, @email)
	end
go

create proc sp_update_nhacc @json nvarchar(max)
as
	begin
		if(@json is not null)
		begin
			select
					JSON_VALUE(ListToEdit.value,'$.id') as ID,
					JSON_VALUE(ListToEdit.value, '$.tenNhaCC') as TenNhaCC,
					JSON_VALUE(ListToEdit.value, '$.sdt') as SDT,
					JSON_VALUE(ListToEdit.value, '$.diaChi') as DiaChi,
					JSON_VALUE(ListToEdit.value, '$.email') as Email
				into #ListToEdit
			from OPENJSON(@json) as ListToEdit
			update NhaCC
			set NhaCC.TenNhaCC = #ListToEdit.TenNhaCC,
				NhaCC.SDT = #ListToEdit.SDT,
				NhaCC.DiaChi = #ListToEdit.DiaChi,
				NhaCC.Email = #ListToEdit.Email
			from #ListToEdit
			where NhaCC.ID = #ListToEdit.ID
		end
	end
go

create proc sp_delete_nhacc @id int
as
	begin	
		delete from DanhMuc where ID = @id
	end
go