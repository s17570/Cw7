using Cw7.DTOs.Requests;
using Cw7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cw7.Controllers
{
    [Route("api/students")]
    [Authorize]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(Program.GetConnectionString()))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT student.indexnumber, student.firstname, student.lastname, student.birthdate, studies.name, enrollment.semester " +
                    "FROM student " +
                    "INNER JOIN enrollment ON student.idenrollment=enrollment.idenrollment " +
                    "INNER JOIN studies ON enrollment.idstudy=studies.idstudy";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = (DateTime)dr["BirthDate"];
                    st.Studies = dr["Name"].ToString();
                    list.Add(st);
                }
            }

            return Ok(list);
        }
    }
}
