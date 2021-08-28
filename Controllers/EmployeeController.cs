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
    public class EmployeeController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select EmployeeID,EmployeeName,Department,MailID,convert(varchar(10),DOJ,120) as DOJ from dbo.Employees";

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

            var command = new SqlCommand(query, conn);

            using (var adapter = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                adapter.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        public string Post(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

  

                string query = @"insert into dbo.Employees (EmployeeName,Department,MailID,DOJ) values (
                '"+ emp.EmployeeName+ @"',
                '"+ emp.Department+ @"',
                '"+ emp.MailID+ @"',
                '"+ emp.DOJ + @"'
                )";

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

        public string Put(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"update dbo.Employees set 
                        EmployeeName ='" + emp.EmployeeName + @"',
                        Department ='" + emp.Department + @"',
                        MailID ='" + emp.MailID + @"',
                        DOJ ='" + emp.DOJ + @"'              
                        where EmployeeID =" + emp.EmployeeID + @"";

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

                string query = @"delete from dbo.Employees where EmployeeID= "+id;

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




