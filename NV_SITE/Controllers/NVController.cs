using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NV_SITE.Models;
using System.Web.Http.Cors;

namespace NV_SITE.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class NVController : ApiController
    {
        [HttpGet]
        [Route("api/nhanviens")]
        public List<ChitietNV> laydanhsach()
        {
            List<ChitietNV> nhanviens = new NV_DAO().laytatca();
            return nhanviens;
        }

        [HttpGet]
        [Route("api/nhanviens/search/{keyword}")]
        public List<ChitietNV> Search(String keyword)
        {
            List<ChitietNV> nhanviens = new NV_DAO().Selectbyword(keyword);
            return nhanviens;
        }

        [HttpGet]
        [Route("api/nhanviens/{manv}")]
        public ChitietNV Getdetails(int manv)
        {
            ChitietNV nhanvien = new NV_DAO().Selectbycode(manv);
            return nhanvien;

        }

        [HttpPost]
        [Route("api/nhanviens")]
        public bool Addnew(ChitietNV newnhanvien)
        {
            bool result = new NV_DAO().Insert(newnhanvien);
            return result;
        }


        [HttpDelete]
        [Route("api/nhanviens/{manv}")]
        public bool Delete(int manv)
        {
            bool result = new NV_DAO().Delete(manv);
            return result;
        }

        [HttpPut]
        [Route("api/nhanviens/{manv}")]
        public bool Update(int manv, ChitietNV newnhanvien)
        {
            if (manv != newnhanvien.Manv) return false;
            bool result = new NV_DAO().Update(newnhanvien);
            return result;
        }
    }
}