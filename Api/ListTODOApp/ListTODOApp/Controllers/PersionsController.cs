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


    }
}




