using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class AdminssionAplicationService
    {
        private readonly TestApiContext Context;
        public AdminssionAplicationService(TestApiContext _context)
        {
            this.Context = _context;
        }

        public Response<AdminssionAplication> save( AdminssionAplication adminssionAplication)
        {
            try
            {
                var currentAdminssionAplication = FindAdminssionAplication(adminssionAplication.Identification);
                if (currentAdminssionAplication!=null)
                    return new Response<AdminssionAplication>("La solicitud ya esta registrada");
                this.Context.AdminssionAplication.Add(adminssionAplication);
                this.Context.SaveChanges();
                return new Response<AdminssionAplication>(adminssionAplication, System.Net.HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new Response<AdminssionAplication>("Error: "+ e);
            }
        }

        public ResponseList<AdminssionAplication> get()
        {
            try
            {
                return new ResponseList<AdminssionAplication>(this.Context.AdminssionAplication.ToList());
            }
            catch (Exception e)
            {
                return new ResponseList<AdminssionAplication>("Error: " + e);
            }

        }

        public Response<AdminssionAplication> update(AdminssionAplication adminssionAplication)
        {
            try
            {
                var currentAdminssionAplication = FindAdminssionAplication(adminssionAplication.Identification);
                if (currentAdminssionAplication==null)
                    return new Response<AdminssionAplication>("La solicitud no se encuentra registrada");
                currentAdminssionAplication.CompareOrUpdate(adminssionAplication);
                this.Context.AdminssionAplication.Update(currentAdminssionAplication);
                this.Context.SaveChanges();
                return new Response<AdminssionAplication>(adminssionAplication, System.Net.HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new Response<AdminssionAplication>("Error: " + e);
            }
        }

        public Response<AdminssionAplication> delete(string _identification)
        {
            try
            {
                var currentAdminssionAplication = FindAdminssionAplication(_identification);
                if (currentAdminssionAplication==null)
                    return new Response<AdminssionAplication>("La solicitud no se encuentra registrada");
                this.Context.AdminssionAplication.Remove(currentAdminssionAplication);
                this.Context.SaveChanges();
                return new Response<AdminssionAplication>(currentAdminssionAplication, System.Net.HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new Response<AdminssionAplication>("Error: " + e);
            }
        }

        private AdminssionAplication FindAdminssionAplication(string _identification)
        {
            var currentAdminssionAplication = this.Context.AdminssionAplication.FirstOrDefault(P=>P.Identification.Equals(_identification));
            return currentAdminssionAplication;
        }


    }
}
