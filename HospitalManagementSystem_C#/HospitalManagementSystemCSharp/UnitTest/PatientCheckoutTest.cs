using HospitalManagementSystemCSharp.Refactoring;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace HospitalManagementSystemCSharp.Tests
{
    [TestFixture]
    public class PatientCheckOutRepositoryTests
    {
        private PatientCheckOutRepository _repository;
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=hms;Integrated Security=True";

        [SetUp]
        public void Setup()
        {
            _repository = new PatientCheckOutRepository();
            ClearTestDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            ClearTestDatabase();
        }

        //Clears test data in the "checkout" and "patient" tables to ensure a clean test environment.
        private void ClearTestDatabase()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var clearCheckout = new SqlCommand("DELETE FROM checkout", con);
                clearCheckout.ExecuteNonQuery();

                var clearPatient = new SqlCommand("DELETE FROM patient", con);
                clearPatient.ExecuteNonQuery();

                con.Close();
            }
        }

        [Test]
        public void LoadPatientDetails_WithExistingPatientId_ReturnsCorrectData()
        {
            //Insert a test patient, but do NOT insert the id manually
            int testPatientId;
            string expectedName = "John Doe";
            string expectedGen = "Male";
            string expectedAge = "30";
            string expectedContact = "123456789";
            string expectedAddr = "123 Street";
            string expectedDisease = "Flu";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var insertPatientCmd = new SqlCommand(
                    "INSERT INTO patient (name, gen, age, cont, addr, disease) " +
                    "VALUES (@name, @gen, @age, @cont, @addr, @disease); " +
                    "SELECT SCOPE_IDENTITY();", con); //SCOPE_IDENTITY returns the generated identity value

                insertPatientCmd.Parameters.AddWithValue("@name", expectedName);
                insertPatientCmd.Parameters.AddWithValue("@gen", expectedGen);
                insertPatientCmd.Parameters.AddWithValue("@age", expectedAge);
                insertPatientCmd.Parameters.AddWithValue("@cont", expectedContact);
                insertPatientCmd.Parameters.AddWithValue("@addr", expectedAddr);
                insertPatientCmd.Parameters.AddWithValue("@disease", expectedDisease);

                //Get the auto-generated id of the inserted patient
                testPatientId = Convert.ToInt32(insertPatientCmd.ExecuteScalar());
                con.Close();
            }

            //Call LoadPatientDetails
            _repository.LoadPatientDetails(testPatientId, out string name, out string gen, out string age, out string contact, out string addr, out string disease);

            //Assert checks
            Assert.AreEqual(expectedName, name);
            Assert.AreEqual(expectedGen, gen);
            Assert.AreEqual(expectedAge, age);
            Assert.AreEqual(expectedContact, contact);
            Assert.AreEqual(expectedAddr, addr);
            Assert.AreEqual(expectedDisease, disease);
        }


        [Test]
        public void LoadPatientDetails_WithNonExistentPatientId_ReturnsEmptyStrings()
        {
            //Call LoadPatientDetails with a non-existent patient id
            _repository.LoadPatientDetails(999, out string name, out string gen, out string age, out string contact, out string addr, out string disease);

            //Assert checks
            Assert.AreEqual(string.Empty, name);
            Assert.AreEqual(string.Empty, gen);
            Assert.AreEqual(string.Empty, age);
            Assert.AreEqual(string.Empty, contact);
            Assert.AreEqual(string.Empty, addr);
            Assert.AreEqual(string.Empty, disease);
        }

        [Test]
        public void SavePatientCheckout_WithValidData_InsertsDataCorrectly()
        {
            //Test data for a patient checkout
            string name = "Jane Doe";
            string gen = "Female";
            string age = "28";
            string contact = "987654321";
            string addr = "456 Avenue";
            string disease = "Cold";
            string dateIn = "2024-12-20";
            string dateOut = "2024-12-21";
            string build = "Building A";
            string roomNo = "101";
            string roomType = "Single";
            string status = "Checked Out";
            string medPrice = "200";
            string total = "500";

            //Call SavePatientCheckout
            _repository.SavePatientCheckout(name, gen, age, contact, addr, disease, dateIn, dateOut, build, roomNo, roomType, status, medPrice, total);

            //Verify that the record was actually inserted into the database
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                var selectCmd = new SqlCommand("SELECT COUNT(*) FROM checkout WHERE name = @name AND contact = @contact", con);
                selectCmd.Parameters.AddWithValue("@name", name);
                selectCmd.Parameters.AddWithValue("@contact", contact);

                int count = (int)selectCmd.ExecuteScalar();
                con.Close();

                Assert.AreEqual(1, count, "The patient checkout record was not inserted correctly.");
            }
        }
    }
}
