use QuanLyNoiThat
go

create procedure sp_get_san_pham_by_id @id nvarchar(10)
as
    begin
      select *
      from SanPham
      where id= @id;
    end;