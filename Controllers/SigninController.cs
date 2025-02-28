using MauiApp2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using static MauiApp2.MainPage;
using static MauiApp2.NewRescue;
using static MauiApp2.Report;

namespace TodoApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        public string _PostT1 { get; set; }
        public string backcolor1 { get; set; }
        public IEnumerable<_doctor> GetDoctors(string CityName)
        {

            List<_doctor> doctorData = new List<_doctor>();
            var conn = new MySqlConnection(Properties.Resources.ConnApi);

            MySqlCommand cmd = new MySqlCommand("GetDoctorsByCity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CityName", CityName);
            conn.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string _TimeBorderVisiblity = "", _Time = "", _StatusBorderVisibility = "";
                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (rd["Sunday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["SunF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["SunT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();
                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                {
                    if (rd["Monday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["MonF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["MonT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();
                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if (rd["Tuesday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["TueF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["TueT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();

                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                {
                    if (rd["Wednesday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["WedF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["WedT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();
                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                {
                    if (rd["Thursday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["ThuF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["ThuT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();
                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                {
                    if (rd["Friday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["FriF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["FriT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();

                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (rd["Saturday"].ToString() == "No")
                    {
                        _TimeBorderVisiblity = "False";
                        _Time = "N/A";
                        _StatusBorderVisibility = "False";
                    }
                    else
                    {
                        _TimeBorderVisiblity = "True";
                        string one = "", two = "";
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["SatF"].ToString(), out TimeSpan sunTTime1))
                        {
                            // Extract only Hours and Minutes
                            one = $"{sunTTime1.Hours:D2}:{sunTTime1.Minutes:D2}";
                        }
                        // Parse SunT value to TimeSpan
                        if (TimeSpan.TryParse(rd["SatT"].ToString(), out TimeSpan sunTTime2))
                        {
                            // Extract only Hours and Minutes
                            two = $"{sunTTime2.Hours:D2}:{sunTTime2.Minutes:D2}";
                        }
                        _Time = one + " - " + two;
                        _StatusBorderVisibility = rd["StatusVisibility"].ToString();

                    }
                }
                _doctor _Doctor = new _doctor();

                if (rd["PostType"].ToString() == "Basic Post")
                {
                    _PostT1 = "";
                    backcolor1 = "False";
                }
                else if (rd["PostType"].ToString() == "Featured Post")
                {
                    _PostT1 = "FEATURED";
                    backcolor1 = "True";
                }
                _Doctor.ID = rd["id"].ToString();
                _Doctor.DName = rd["Firstname"].ToString() + " " + rd["LastName"].ToString();
                _Doctor.DUName = rd["DoctorNameU"].ToString();
                _Doctor._Gen = rd["Gender"].ToString();
                _Doctor.DImg = rd["DoctorImage"].ToString();
                _Doctor._DImgN = rd["DoctorImageN"].ToString();
                _Doctor._sunday = rd["Sunday"].ToString();
                _Doctor._sunf = rd["SunF"].ToString();
                _Doctor._sunt = rd["SunT"].ToString();
                _Doctor._monday = rd["Monday"].ToString();
                _Doctor._monf = rd["MonF"].ToString();
                _Doctor._mont = rd["MonT"].ToString();
                _Doctor._tuesday = rd["Tuesday"].ToString();
                _Doctor._tuef = rd["TueF"].ToString();
                _Doctor._tuet = rd["TueT"].ToString();
                _Doctor._wednesday = rd["Wednesday"].ToString();
                _Doctor._wedf = rd["WedF"].ToString();
                _Doctor._wedt = rd["WedT"].ToString();
                _Doctor._thursday = rd["Thursday"].ToString();
                _Doctor._thuf = rd["ThuF"].ToString();
                _Doctor._thut = rd["ThuT"].ToString();
                _Doctor._friday = rd["Friday"].ToString();
                _Doctor._frif = rd["FriF"].ToString();
                _Doctor._frit = rd["FriT"].ToString();
                _Doctor._saturday = rd["Saturday"].ToString();
                _Doctor._satf = rd["SatF"].ToString();
                _Doctor._satt = rd["SatT"].ToString();
                _Doctor._cont1 = rd["Contact1"].ToString();
                _Doctor._cont2 = rd["Contact2"].ToString();
                _Doctor._specs = rd["Specs"].ToString();
                _Doctor._SImg = rd["SignboardImage"].ToString();
                _Doctor._SImgN = rd["SignboardImageN"].ToString();
                _Doctor._HID = rd["HospitalID"].ToString();
                _Doctor._desc = rd["Description"].ToString();
                _Doctor.PostT = _PostT1;
                _Doctor._PckgN = rd["PackageN"].ToString();
                _Doctor._PckgF = rd["PackageF"].ToString();
                _Doctor._PckgT = rd["PackageT"].ToString();
                _Doctor._PaymentT = rd["PaymentType"].ToString();
                _Doctor._Amount = rd["Amount"].ToString();
                _Doctor._PaymentBy = rd["PaymentBy"].ToString();
                // _PaymentDate =Convert.ToDateTime(rd["PaymentDate"]),
                _Doctor._TransactionId = rd["TransactionId"].ToString();
                _Doctor.backcolor = backcolor1;
                _Doctor.HName = rd["HospitalName"].ToString()+", "+ rd["City"].ToString();
                _Doctor.HUName = rd["HospitalNameU"].ToString() + " ،" + rd["CityU"].ToString();
                _Doctor.HImg = rd["HospitalImage"].ToString();
                _Doctor.Address = rd["Street"].ToString() + ", " + rd["Block"].ToString() + ", " + " Near: " + rd["Near"].ToString() + ", " + rd["City"].ToString();
                _Doctor.AddressU = rd["StreetU"].ToString() + " ،" + rd["BlockU"].ToString() + "، " + " نزد :" + rd["NearU"].ToString() + " ،" + rd["CityU"].ToString();
                _Doctor.Fname = rd["Firstname"].ToString();
                _Doctor.Lname = rd["LastName"].ToString();
                _Doctor._Hcont1= rd["HContact1"].ToString();
                _Doctor._Hcont2= rd["HContact2"].ToString();
                _Doctor._Hwhatsapp = rd["HWhatsapp"].ToString();
                _Doctor.TimeBorderVisiblity = _TimeBorderVisiblity;
                _Doctor.Time = _Time;
                _Doctor.StatusBorderVisibility = _StatusBorderVisibility;

                doctorData.Add(_Doctor);
            }
            return doctorData;
            rd.Close();
            conn.Close();
        }
        public IEnumerable<_hospitalsort> GetHospitalsSort()
        {

            List<_hospitalsort> hospitalData = new List<_hospitalsort>();
            var conn = new MySqlConnection(Properties.Resources.ConnApi);

            MySqlCommand cmd = new MySqlCommand("sp_SelectHospitalSort", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                _hospitalsort _Hospital = new _hospitalsort();

                _Hospital.ID = rd["id"].ToString();
                _Hospital.HName = rd["HospitalName"].ToString();
                _Hospital.HUName = rd["HospitalNameU"].ToString();
                _Hospital.Address = rd["Street"].ToString() + ", " + rd["Block"].ToString() + ", " + " Near: " + rd["Near"].ToString() + ", " + rd["City"].ToString();
                _Hospital.HImg = rd["HospitalImage"].ToString();
                _Hospital.AddressU = rd["StreetU"].ToString() + " ،" + rd["BlockU"].ToString() + "، " + " نزد :" + rd["NearU"].ToString() + " ،" + rd["CityU"].ToString();
                _Hospital._sunday = rd["Sunday"].ToString();
                _Hospital._sunf = rd["SunF"].ToString();
                _Hospital._sunt = rd["SunTo"].ToString();
                _Hospital._monday = rd["Monday"].ToString();
                _Hospital._monf = rd["MonF"].ToString();
                _Hospital._mont = rd["MonT"].ToString();
                _Hospital._tuesday = rd["Tuesday"].ToString();
                _Hospital._tuef = rd["TueF"].ToString();
                _Hospital._tuet = rd["TueT"].ToString();
                _Hospital._wednesday = rd["Wednesday"].ToString();
                _Hospital._wedf = rd["WedF"].ToString();
                _Hospital._wedt = rd["WedT"].ToString();
                _Hospital._thursday = rd["Thursday"].ToString();
                _Hospital._thuf = rd["ThuF"].ToString();
                _Hospital._thut = rd["ThuT"].ToString();
                _Hospital._friday = rd["Friday"].ToString();
                _Hospital._frif = rd["FriF"].ToString();
                _Hospital._frit = rd["FriT"].ToString();
                _Hospital._saturday = rd["Saturday"].ToString();
                _Hospital._satf = rd["SatF"].ToString();
                _Hospital._satt = rd["SatT"].ToString();
                _Hospital._cont1 = rd["Contact1"].ToString();
                _Hospital._cont2 = rd["Contact2"].ToString();
                _Hospital._whatsapp = rd["Whatsapp"].ToString();
                _Hospital._desc = rd["Description"].ToString();
                _Hospital._HImageN = rd["HospitalImageN"].ToString();
                _Hospital._SImageN = rd["SignboardImageN"].ToString();

                hospitalData.Add(_Hospital);
            }
            return hospitalData;
            rd.Close();
            conn.Close();
        }
        public void newrep(_repo Repo)
        {
            var conn = new MySqlConnection(Properties.Resources.ConnApi);
            MySqlCommand com = new MySqlCommand("sp_newreport", conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("_catname", Repo.catname);
            com.Parameters.AddWithValue("_catid", Repo.catid);
            com.Parameters.AddWithValue("_exist", Repo.exist);
            com.Parameters.AddWithValue("_Hid", Repo.hid);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public IEnumerable<_rescue> GetRescues(string CityName)
        {
            List<_rescue> rescueData = new List<_rescue>();
            var conn = new MySqlConnection(Properties.Resources.ConnApi);

            MySqlCommand cmd = new MySqlCommand("sp_SelectRescue", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CityName", CityName);
            conn.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                _rescue _Rescue = new _rescue();

                _Rescue.ID = rd["id"].ToString();
                _Rescue.RName = rd["RName"].ToString();
                _Rescue.RUName = rd["RNameU"].ToString();
                _Rescue.DName = rd["DriverName"].ToString();
                _Rescue.City = rd["City"].ToString();
                _Rescue.Contact1 = rd["Contact1"].ToString();
                _Rescue.Contact2 = rd["Contact2"].ToString();
                _Rescue.Whatsapp = rd["Whatsapp"].ToString();

                rescueData.Add(_Rescue);
            }
            return rescueData;
            rd.Close();
            conn.Close();
        }
    }
}
