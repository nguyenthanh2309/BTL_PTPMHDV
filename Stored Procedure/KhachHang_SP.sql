use QuanLyNoiThat
go

create proc sp_get_khach_hang_by_id @id int
as
	begin
		select * from KhachHang where ID = @id;
	end
go

create proc sp_get_all_khach_hang 
as
	begin	
		select * from KhachHang 
	end
go

create proc sp_create_khach_hang 
@tenkh nvarchar(max),
@sdt nvarchar(12),
@diachi nvarchar(max)
as
	begin
		insert into KhachHang values (
			@tenkh, @sdt, @diachi
		)
	end
go

create proc sp_update_khach_hang @json nvarchar(max)
as
	begin
		if(@json is not null)
		begin
			select
					JSON_VALUE(ListToEdit.value,'$.id') as ID,
					JSON_VALUE(ListToEdit.value, '$.tenKH') as TenKhachHang,
					JSON_VALUE(ListToEdit.value, '$.sdt') as SDT,
					JSON_VALUE(ListToEdit.value, '$.diaChi') as DiaChi
				into #ListToEdit
			from OPENJSON(@json) as ListToEdit
			update KhachHang
			set KhachHang.TenKH = #ListToEdit.TenKhachHang,
				KhachHang.SDT = #ListToEdit.SDT,
				KhachHang.SDT = #ListToEdit.SDT
			from #ListToEdit
			where KhachHang.ID = #ListToEdit.ID
		end
	end
go

create proc sp_delete_khach_hang @id int
as
	begin
		delete from KhachHang where ID = @id
	end
go