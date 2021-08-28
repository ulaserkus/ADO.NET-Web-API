using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select DepartmentID,DepartmentName from dbo.Departments";

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

            var command = new SqlCommand(query, conn);

            using (var adapter  = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                adapter.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Department dp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Departments values ('"+dp.DepartmentName+@"')";

                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, conn);

                using (var adapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    adapter.Fill(table);
                }

                return "Added successfully";


            }
            catch (Exception ex)
            {
                return "Failed to add";
              
            }

        }

        public string Put(Department dp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"update dbo.Departments set DepartmentName ='"+dp.DepartmentName+
                    @"'where DepartmentID ="+dp.DepartmentID+@"";

                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, conn);

                using (var adapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    adapter.Fill(table);
                }

                return "Updated successfully";


            }
            catch (Exception ex)
            {
                return "Failed to update";

            }

        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"delete from dbo.Departments where DepartmentID= " + id;

                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, conn);

                using (var adapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    adapter.Fill(table);
                }

                return "Deleted successfully";


            }
            catch (Exception ex)
            {
                return "Failed to delete";

            }

        }



    }
}
