﻿using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoanBusiness : ITaiKhoanBusiness
    {
        private ITaiKhoanRepos _res;
        public TaiKhoanBusiness(ITaiKhoanRepos res)
        {
            _res = res;
        }
        public TaiKhoan GetTaiKhoanByID(int id)
        {
            return _res.GetTaiKhoanByID(id);
        }
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            return _res.GetAllTaiKhoan();
        }
        public void Create(TaiKhoan tk)
        {
            _res.Create(tk);
        }
        public void Update(string json)
        {
            _res.Update(json);
        }

        public void Delete(int id)
        {
            _res.Delete(id);
        }
    }
}
