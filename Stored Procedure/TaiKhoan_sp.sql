use QuanLyNoiThat
go

create proc sp_get_tk_by_id @id nvarchar(10)
as
	begin 
		select * from TaiKhoan where ID = @id
	end
go

create proc sp_create_tk @id nvarchar(10),
@tentk nvarchar(max),
@matkhau nvarchar(max),
@email nvarchar(max),
@loaitkid nvarchar(10)
as
	begin
		insert into TaiKhoan values (
			@id, @tentk, @matkhau, @email, @loaitkid
		)
	end
go

create proc sp_update_tk @id nvarchar(10),
@tentk nvarchar(max),
@matkhau nvarchar(max),
@email nvarchar(max),
@loaitkid nvarchar(10)
as
	begin
		update TaiKhoan
		set TenTK = @tentk,
			MatKhau = @matkhau,
			Email = @email,
			LoaiTaiKhoanID = @loaitkid
		where ID = @id
	end
go

create proc sp_delete_tk @id nvarchar(10)
as
	begin 
		delete from TaiKhoan where ID = @id
	end
go