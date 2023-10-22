﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IHoaDonBusiness
    {
        HoaDon GetHoaDonByID(string id);
        void Create(HoaDon hd);
        void Update(HoaDon hd);
        void Delete(string id);
    }
}