using Dapper;
using ListTODOApp.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace ListTODOApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult getPersions()
        {
            try
            {
                string SQLconnectstr = "Server=localhost;Database=persion;User Id=lloyy;Password=Handanba1.;";
                var con = new MySqlConnection(SQLconnectstr);
                string sellect = "SELECT * FROM persioninfo";
                con.Open();
                var listpersion = con.Query<Persion>(sellect);
                if (listpersion != null)
                {
                    return StatusCode(StatusCodes.Status200OK, listpersion);
                }
                else return StatusCode(StatusCodes.Status404NotFound, "Khong co thong tin naio");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpDelete("{PersionCode}")]
        public IActionResult DeletePerison([FromRoute]string PersionCode)
        {

            try
            {
                string SQLconnectstr = "Server=localhost;Database=persion;User Id=lloyy;Password=Handanba1.;";
                var con = new MySqlConnection(SQLconnectstr);
                string sellect = "DELETE FROM persioninfo WHERE PersionCode = @PersionCode";
          
                var parrameter = new DynamicParameters();
                parrameter.Add("@PersionCode", PersionCode);
                var delete = con.Execute(sellect, parrameter);
                if (delete > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, PersionCode);
                }
                else return StatusCode(StatusCodes.Status404NotFound, "Khong co thong tin naio");
            }
            catch (MySqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreatePrison(Persion persion)
        {
            try
            {
                string SQLconnectstr = "Server=localhost;Database=persion;User Id=lloyy;Password=Handanba1.;";
                var con = new MySqlConnection(SQLconnectstr);
               
                string test = @"INSERT INTO persioninfo VALUES (@PersionCode,@PersionName,@Brithday,@Gender,@Address);";
                var parrameter = new DynamicParameters();
                parrameter.Add("@PersionCode", persion.PersionCode);
                parrameter.Add("@PersionName", persion.PersionName);
                parrameter.Add("@Brithday", persion.Birthday);
                parrameter.Add("@Gender", persion.Gender);
                parrameter.Add("@Address", persion.Adress);

                var addPersion = con.Execute(test, parrameter);
                if (addPersion > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, parrameter);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (MySqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{PersionCode}")]
        public IActionResult EditPersion([FromRoute]string PersionCode, Persion persion) {

            try
            {
                string SQLconnectstr = "Server=localhost;Database=persion;User Id=lloyy;Password=Handanba1.;";
                var con = new MySqlConnection(SQLconnectstr);
                string update = $"UPDATE persioninfo SET PersionName =@PersionName,Gender=@Gender WHERE PersionCode = '{PersionCode}'; ";
                var parameter = new DynamicParameters();
                
                parameter.Add("@PersionName", persion.PersionName);
                parameter.Add("@Gender", persion.Gender);


                var updatepersion = con.Execute(update, parameter);
                if (updatepersion > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, parameter);
                }
                else return StatusCode(StatusCodes.Status400BadRequest, "");
            }
            catch (MySqlException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}




