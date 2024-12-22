using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using HospitalManagementSystemCSharp.Refactoring;

namespace HospitalManagementSystem.Tests
{
    [TestFixture]
    public class CheckoutRepositoryTests
    {
        private CheckoutRepository _checkoutRepository;
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        [SetUp]
        public void SetUp()
        {
            //Initialize the class under test
            _checkoutRepository = new CheckoutRepository();
        }

        [Test]
        public void GetAllCheckouts_WhenCalled_ReturnsDataTable()
        {
            //Seed a test record in the checkout table
            int checkoutId;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var insertCmd = new SqlCommand(
                    "INSERT INTO checkout (name, gen, age, contact, addr, disease, date_in, date_out, build, r_no, r_type, status, med_price, total) " +
                    "VALUES (@name, @gen, @age, @contact, @addr, @disease, @date_in, @date_out, @build, @r_no, @r_type, @status, @med_price, @total); " +
                    "SELECT SCOPE_IDENTITY();", con);

                insertCmd.Parameters.AddWithValue("@name", "Test Name");
                insertCmd.Parameters.AddWithValue("@gen", "Male");
                insertCmd.Parameters.AddWithValue("@age", "40");
                insertCmd.Parameters.AddWithValue("@contact", "123456789");
                insertCmd.Parameters.AddWithValue("@addr", "Test Address");
                insertCmd.Parameters.AddWithValue("@disease", "Test Disease");
                insertCmd.Parameters.AddWithValue("@date_in", DateTime.Now.ToString("yyyy-MM-dd"));
                insertCmd.Parameters.AddWithValue("@date_out", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                insertCmd.Parameters.AddWithValue("@build", "A");
                insertCmd.Parameters.AddWithValue("@r_no", "102");
                insertCmd.Parameters.AddWithValue("@r_type", "Single");
                insertCmd.Parameters.AddWithValue("@status", "Checked Out");
                insertCmd.Parameters.AddWithValue("@med_price", "100.00");
                insertCmd.Parameters.AddWithValue("@total", "200.00");

                //Get the generated ID of the inserted record
                checkoutId = Convert.ToInt32(insertCmd.ExecuteScalar());
                con.Close();
            }

            //Call GetAllCheckouts to fetch data
            DataTable result = _checkoutRepository.GetAllCheckouts();

            //Check if the result is not null and contains rows
            Assert.IsNotNull(result, "The result should not be null.");
            Assert.IsTrue(result.Rows.Count > 0, "The result should contain rows.");

            //Delete the test record from the checkout table
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var deleteCmd = new SqlCommand("DELETE FROM checkout WHERE id = @id", con);
                deleteCmd.Parameters.AddWithValue("@id", checkoutId);
                deleteCmd.ExecuteNonQuery();
                con.Close();
            }
        }


        [Test]
        public void GetCheckoutById_WhenCalledWithValidId_ReturnsDataTable()
        {
            //Insert a test checkout record and get the auto-generated ID
            int checkoutId;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var insertCmd = new SqlCommand(
                    "INSERT INTO checkout (name, gen, age, contact, addr, disease, date_in, date_out, build, r_no, r_type, status, med_price, total) " +
                    "VALUES (@name, @gen, @age, @contact, @addr, @disease, @date_in, @date_out, @build, @r_no, @r_type, @status, @med_price, @total); " +
                    "SELECT SCOPE_IDENTITY();", con);

                insertCmd.Parameters.AddWithValue("@name", "John Doe");
                insertCmd.Parameters.AddWithValue("@gen", "Male");
                insertCmd.Parameters.AddWithValue("@age", "30");
                insertCmd.Parameters.AddWithValue("@contact", "123456789");
                insertCmd.Parameters.AddWithValue("@addr", "123 Street");
                insertCmd.Parameters.AddWithValue("@disease", "Flu");
                insertCmd.Parameters.AddWithValue("@date_in", "2024-12-15");
                insertCmd.Parameters.AddWithValue("@date_out", "2024-12-20");
                insertCmd.Parameters.AddWithValue("@build", "A");
                insertCmd.Parameters.AddWithValue("@r_no", "101");
                insertCmd.Parameters.AddWithValue("@r_type", "Single");
                insertCmd.Parameters.AddWithValue("@status", "Checked Out");
                insertCmd.Parameters.AddWithValue("@med_price", "100.00");
                insertCmd.Parameters.AddWithValue("@total", "500.00");

                //Get the auto-generated checkout ID
                checkoutId = Convert.ToInt32(insertCmd.ExecuteScalar());
                con.Close();
            }

            //Call GetCheckoutById with the generated ID
            DataTable result = _checkoutRepository.GetCheckoutById(checkoutId);

            //Check if the result contains the expected data
            Assert.IsNotNull(result, "The result should not be null.");
            Assert.AreEqual(1, result.Rows.Count, "There should be exactly one row.");
            Assert.AreEqual(checkoutId, Convert.ToInt32(result.Rows[0]["id"]), "The ID should match the inserted checkout ID.");

            //Delete the test data
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var deleteCmd = new SqlCommand("DELETE FROM checkout WHERE id = @id", con);
                deleteCmd.Parameters.AddWithValue("@id", checkoutId);
                deleteCmd.ExecuteNonQuery();
                con.Close();
            }
        }

        [Test]
        public void GetCheckoutById_WhenCalledWithInvalidId_ReturnsEmptyDataTable()
        {
            //Generate an invalid ID (we assume 999999 does not exist)
            int invalidCheckoutId = 999999;

            //Call GetCheckoutById with the invalid ID
            DataTable result = _checkoutRepository.GetCheckoutById(invalidCheckoutId);

            //Check if the result is empty
            Assert.IsNotNull(result, "The result should not be null.");
            Assert.AreEqual(0, result.Rows.Count, "The result should be empty.");
        }
    }
}
