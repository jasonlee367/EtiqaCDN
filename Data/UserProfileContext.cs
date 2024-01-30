using MySql.Data.MySqlClient;
using System.Data;
using EtiqaCDN.Models;
using EtiqaCDN.Models.UserDto;

namespace EtiqaCDN.Data
{
    public class UserProfileContext : IUserProfileContext
    {
        private IConfiguration _config;

        public UserProfileContext(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Users> GetUserProfileContext(string Id)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = _config["DBConnection"];
            MySqlCommand cmd = new MySqlCommand();

            conn.Open();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "SP_QueryUserInfoById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("userId", Id);
                cmd.Parameters["userId"].Direction = ParameterDirection.Input;

                await cmd.ExecuteNonQueryAsync();
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    await dataAdapter.FillAsync(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        return GetUserProfileFromDataRow(dataTable.Rows[0]);
                    }

                    dataTable.Clear();
                }
                return null;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            if (conn != null)
                await conn.CloseAsync();
            return null;
        }

        public async Task<bool> DeleteUserProfileContext(string Id)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = _config["DBConnection"];
            MySqlCommand cmd = new MySqlCommand();
            int totalDeleted = 0;

            conn.Open();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "SP_DeleteUserInfoById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("userId", Id);
                cmd.Parameters["userId"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("count", totalDeleted);
                cmd.Parameters["count"].Direction = ParameterDirection.Output;

                var affectedRow = await cmd.ExecuteNonQueryAsync();
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    totalDeleted = (int)cmd.Parameters["count"].Value;
                    //await dataAdapter.FillAsync(dataTable);
                    if (totalDeleted > 0)
                    {
                        return true;
                    }                    
                    dataTable.Clear();
                }
                return false;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            if (conn != null)
                await conn.CloseAsync();
            return false;
        }

        public async Task<Users> UpdateUserProfileContext(Users users, string Id)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = _config["DBConnection"];
            MySqlCommand cmd = new MySqlCommand();
            int totalUpdated = 0;

            conn.Open();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "SP_UpdateUserInfoById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("ptId", Id);
                cmd.Parameters["ptId"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptName", users.UserName);
                cmd.Parameters["ptName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("pthobby", users.Hobby);
                cmd.Parameters["pthobby"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptIc_Passport", users.IC_Passport);
                cmd.Parameters["ptIc_Passport"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptNationality", users.Nationality);
                cmd.Parameters["ptNationality"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptRace", users.Race);
                cmd.Parameters["ptRace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptGender", users.Gender);
                cmd.Parameters["ptGender"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptDob", users.DOB);
                cmd.Parameters["ptDob"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptEmail", users.Email);
                cmd.Parameters["ptEmail"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptPhoneNumber", users.PhoneNumber);
                cmd.Parameters["ptPhoneNumber"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptSkillsets", users.Skillsets);
                cmd.Parameters["ptSkillsets"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptAddress1", users.Address1);
                cmd.Parameters["ptAddress1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptAddress2", users.Address2);
                cmd.Parameters["ptAddress2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptPostcode", users.Postcode);
                cmd.Parameters["ptPostcode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptCity", users.City);
                cmd.Parameters["ptCity"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptState", users.State);
                cmd.Parameters["ptState"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptCountry", users.Country);
                cmd.Parameters["ptCountry"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("count", totalUpdated);
                cmd.Parameters["count"].Direction = ParameterDirection.Output;

                var affectedRow = await cmd.ExecuteNonQueryAsync();
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    totalUpdated = (int)cmd.Parameters["count"].Value;
                    //await dataAdapter.FillAsync(dataTable);
                    if (totalUpdated > 0)
                    {
                        return await GetUserProfileContext(Id);
                    }
                    dataTable.Clear();
                }
                return null;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            if (conn != null)
                await conn.CloseAsync();
            return null;
        }

        public async Task<bool> AddUserProfileContext(Users users)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = _config["DBConnection"];
            MySqlCommand cmd = new MySqlCommand();
            int totalAdded = 0;

            conn.Open();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "SP_AddUserInfoById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("ptName", users.UserName);
                cmd.Parameters["ptName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("pthobby", users.Hobby);
                cmd.Parameters["pthobby"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptIc_Passport", users.IC_Passport);
                cmd.Parameters["ptIc_Passport"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptNationality", users.Nationality);
                cmd.Parameters["ptNationality"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptRace", users.Race);
                cmd.Parameters["ptRace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptGender", users.Gender);
                cmd.Parameters["ptGender"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptDob", users.DOB);
                cmd.Parameters["ptDob"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptEmail", users.Email);
                cmd.Parameters["ptEmail"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptContactNo", users.PhoneNumber);
                cmd.Parameters["ptContactNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptSkillsets", users.Skillsets);
                cmd.Parameters["ptSkillsets"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptAddress1", users.Address1);
                cmd.Parameters["ptAddress1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptAddress2", users.Address2);
                cmd.Parameters["ptAddress2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptPostcode", users.Postcode);
                cmd.Parameters["ptPostcode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptCity", users.City);
                cmd.Parameters["ptCity"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptState", users.State);
                cmd.Parameters["ptState"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("ptCountry", users.Country);
                cmd.Parameters["ptCountry"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("count", totalAdded);
                cmd.Parameters["count"].Direction = ParameterDirection.Output;

                var affectedRow = await cmd.ExecuteNonQueryAsync();
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    totalAdded = (int)cmd.Parameters["count"].Value;
                    if (totalAdded > 0)
                    {
                        return true;
                    }
                    dataTable.Clear();
                }
                return false;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            if (conn != null)
                await conn.CloseAsync();
            return false;
        }

        private Users GetUserProfileFromDataRow(DataRow row)
        {
            var userProfile = new Users
            {
                UserName = row.Field<string>("UserName") ?? string.Empty,
                Hobby = row.Field<string>("hobby") ?? string.Empty,
                IC_Passport = row.Field<string>("IC_Passport") ?? string.Empty,
                Nationality = row.Field<string>("Nationality") ?? string.Empty,
                Race = row.Field<string>("Race") ?? string.Empty,
                Gender = row.Field<string>("Gender") ?? string.Empty,
                DOB = row.Field<string>("DOB") ?? string.Empty,
                Email = row.Field<string>("Email") ?? string.Empty,
                PhoneNumber = row.Field<string>("phoneNumber") ?? string.Empty,
                Skillsets = row.Field<string>("skillsets") ?? string.Empty,
                Address1 = row.Field<string>("Address1") ?? string.Empty,
                Address2 = row.Field<string>("Address2") ?? string.Empty,
                Postcode = row.Field<string>("Postcode") ?? string.Empty,
                City = row.Field<string>("City") ?? string.Empty,
                State = row.Field<string>("State") ?? string.Empty,
                Country = row.Field<string>("Country") ?? string.Empty
            };

            return userProfile;
        }

		private Users GetASPUserProfileFromDataRow(DataRow row)
		{
			var userProfile = new Users
			{
				UserName = row.Field<string>("username") ?? string.Empty,
				Email = row.Field<string>("mail") ?? string.Empty,
				Role = row.Field<string>("RoleId") ?? string.Empty,
			};

			return userProfile;
		}

		public async Task<Users> GetAspUserProfileContext(UserDto users)
		{
			DataTable dataTable = new DataTable();
			MySqlConnection conn = new MySqlConnection();
			conn.ConnectionString = _config["DBConnection"];
			MySqlCommand cmd = new MySqlCommand();

			conn.Open();
			cmd.Connection = conn;

			try
			{
				cmd.CommandText = "SP_QueryAspUserInfoById";
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("email", users.Email);
				cmd.Parameters["email"].Direction = ParameterDirection.Input;

				cmd.Parameters.AddWithValue("password", users.Password);
				cmd.Parameters["password"].Direction = ParameterDirection.Input;

				await cmd.ExecuteNonQueryAsync();
				using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
				{
					await dataAdapter.FillAsync(dataTable);
					if (dataTable.Rows.Count > 0)
					{
						return GetASPUserProfileFromDataRow(dataTable.Rows[0]);
					}

					dataTable.Clear();
				}
				return null;
			}
			catch (MySqlException e)
			{
				Console.Write(e.Message);
			}
			if (conn != null)
				await conn.CloseAsync();
			return null;
		}
	}
}
