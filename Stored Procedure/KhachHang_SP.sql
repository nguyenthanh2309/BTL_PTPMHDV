use QuanLyNoiThat
go

create proc sp_get_khach_hang_by_id @id int
as
	begin
		select * from KhachHang where ID = @id;
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

create proc sp_update_khach_hang @id int,
@tenkh nvarchar(max),
@sdt nvarchar(12),
@diachi nvarchar(max)
as
	begin 
		update KhachHang
		set TenKH = @tenkh,
			SDT = @sdt,
			DiaChi = @diachi
		where ID = @id
	end
go

create proc sp_delete_khach_hang @id int
as
	begin
		delete from KhachHang where ID = @id
	end
go