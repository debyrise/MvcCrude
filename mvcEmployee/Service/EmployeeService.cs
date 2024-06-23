using Microsoft.Data.SqlClient;
using mvcEmployee.Models;

namespace mvcEmployee.Service
{
    public class EmployeeService:IEmployeeService
    {
        public readonly IConfiguration _Configuration;

        public EmployeeService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void CREATEEMPLOYEE(Employees model)
        {
            var connectionString = _Configuration.GetConnectionString("ConnectionString");
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Employee (EmployeeName, PhoneNo, Email, Address, Gender, WorkType, Role, DOB) " +
                    "Values (@EmployeeName, @PhoneNo, @Email, @Address, @Gender, @WorkType, @Role, @DOB)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("EmployeeName", model.EmployeeName);
                cmd.Parameters.AddWithValue("PhoneNo", model.PhoneNo);
                cmd.Parameters.AddWithValue("Email", model.Email);
                cmd.Parameters.AddWithValue("Address", model.Address);
                cmd.Parameters.AddWithValue("Gender", model.Gender);
                cmd.Parameters.AddWithValue("WorkType", model.WorkType);
                cmd.Parameters.AddWithValue("Role", model.Role);
                cmd.Parameters.AddWithValue("DOB", model.DOB);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();    
            }
        }

        public IEnumerable<Employees> GetAllEmployee()
        {
            var List = new List<Employees>();
            var connectionString = _Configuration.GetConnectionString("ConnectionString");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Employ = new Employees()
                    {
                        Id = (int)reader["Id"],
                        EmployeeName = (string)reader["EmployeeName"],
                        PhoneNo = (string)reader["PhoneNo"],
                        Email = (string)reader["Email"],
                        Address = (string)reader["Address"],
                        Gender = (string)reader["Gender"],
                        WorkType = (string)reader["WorkType"],
                        Role = (string)reader["Role"],
                        DOB = (DateTime)reader["DOB"]


                    };
                    List.Add(Employ);
                }
                con.Close();

            }
            return List;



        }

    }


}
