using Domain.Donne;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class ProfileRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public ProfileRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); ;
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<ProfileModel> GetAllProfiles()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<ProfileModel> listProfileModel = new List<ProfileModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProfileGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProfileModel profileModel = new ProfileModel();
                    profileModel.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    profileModel.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    profileModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    profileModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    profileModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    profileModel.UserName = Convert.ToString(rdr["UserName"]);
                    listProfileModel.Add(profileModel);
                }
            }
            return listProfileModel;
        }

        public ProfileModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            ProfileModel profileModel = new ProfileModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProfileGetById", con);
                cmd.Parameters.AddWithValue("@ProfileId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    profileModel.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    profileModel.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    profileModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    profileModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    profileModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    profileModel.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            return profileModel;
        }

        public void Insert(ProfileModel profileModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileInsert", con);
            cmd.Parameters.AddWithValue("@ProfileName", profileModel.ProfileName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", profileModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", profileModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int ProfileId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileDelete", con);
            cmd.Parameters.AddWithValue("@ProfileId", ProfileId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(ProfileModel profileModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileUpdate", con);
            cmd.Parameters.AddWithValue("@ProfileId", profileModel.ProfileId);
            cmd.Parameters.AddWithValue("@ProfileName", profileModel.ProfileName);
            cmd.Parameters.AddWithValue("@DateInsert", profileModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", profileModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", profileModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
