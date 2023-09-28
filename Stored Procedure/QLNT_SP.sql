use QuanLyNoiThat
go

create proc sp_get_san_pham_by_id @id nvarchar(10)
as
    begin
      select *
      from SanPham
      where id= @id;
    end;
go

create proc sp_create_san_pham @id nvarchar(10),
@tensp nvarchar(max),
@phanloaiid nvarchar(10),
@nhaccid nvarchar(10),
@gia int,
@vatlieu nvarchar(max),
@kichthuoc nvarchar(max)
as
	begin 
		insert into SanPham values (
			@id, @tensp, @phanloaiid, @nhaccid, @gia, @vatlieu, @kichthuoc
		)
	end
go

create proc sp_update_san_pham @id nvarchar(10),
@tensp nvarchar(max),
@phanloaiid nvarchar(10),
@nhaccid nvarchar(10),
@gia int,
@vatlieu nvarchar(max),
@kichthuoc nvarchar(max)
as
	begin
		update SanPham
		set TenSP = @tensp,
		PhanLoaiID = @phanloaiid,
		NhaCCID = @nhaccid,
		Gia = @gia,
		VatLieu = @vatlieu,
		KichThuoc = @kichthuoc
		where ID = @id
	end
go

create proc sp_delete_san_pham @id nvarchar(10)
as 
	begin
		delete from SanPham where ID = @id
	end
go