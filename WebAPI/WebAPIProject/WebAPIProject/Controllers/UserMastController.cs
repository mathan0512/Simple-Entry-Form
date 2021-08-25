using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPIProject.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMastController : ControllerBase
    {
        private readonly IConfiguration _Iconfigration;
        private readonly IWebHostEnvironment _env;

        public UserMastController(IConfiguration configuration,IWebHostEnvironment env)
        {

            _Iconfigration = configuration;
            _env = env;
        }

        [HttpGet]

        public JsonResult Get()
        {
            try
            {
                string query = @"select Userid,UserName,Department,ProfileImage from UserTable";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult(table);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult Post(UserMast Userm)
        {
            try
            {
                string query = @"
                            insert into UserTable (UserName,Department,ProfileImage)
                            values(
                            '" + Userm.UserName + @"'
                            ,'" + Userm.Department + @"'
                            ,'" + Userm.ProfileImage + @"'
                            )
                                ";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Sucessfully added !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public JsonResult Put(UserMast Userm)
        {
            try
            {
                string query = @"                            
                                update UserTable SET 
                                UserName = '" + Userm.UserName + @"' 
                                ,Department = '" + Userm.Department + @"' 
                                ,ProfileImage = '" + Userm.ProfileImage + @"' 
                                where Userid = " + Userm.Userid + @"";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Suucessfully Updated !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                string query = @"                            
                                Delete from  UserTable                                  
                                where Userid = " + id + @"";
                DataTable table = new DataTable();
                string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
                SqlDataReader MyReader;
                using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
                {

                    myCon.Open();
                    using (SqlCommand myCommend = new SqlCommand(query, myCon))
                    {
                        MyReader = myCommend.ExecuteReader();
                        table.Load(MyReader);
                        MyReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Suucessfully Deleted !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("SaveFile")]
        [HttpPost]

        public JsonResult SaveFile() {
            try
            {
                var httprequest = Request.Form;
                var postfile = httprequest.Files[0];
                string filename = postfile.FileName;
                var psycalpath = _env.ContentRootPath + "/Snaps/" + filename;

                using (var stream = new FileStream(psycalpath,FileMode.Create))
                {
                    postfile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [Route("getAlldepartment")]

        public JsonResult getAlldepartment() {
            string query = @"select Departname from Department";
            DataTable table = new DataTable();
            string SqlDataSorce = _Iconfigration.GetConnectionString("UserAppCon");
            SqlDataReader MyReader;
            using (SqlConnection myCon = new SqlConnection(SqlDataSorce))
            {

                myCon.Open();
                using (SqlCommand myCommend = new SqlCommand(query, myCon))
                {
                    MyReader = myCommend.ExecuteReader();
                    table.Load(MyReader);
                    MyReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
