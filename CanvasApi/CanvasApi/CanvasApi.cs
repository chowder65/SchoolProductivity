using CanvasApi.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("CanvasApi")]
public class CanvasApiController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return "Hallo";
    }

    [HttpGet]
    [Route("/GetAssignments")]
    public ActionResult<Assignment[]> GetAssignments(){
        return null;
    }

    [HttpDelete]
    [Route("DeleteAssignment")]
    public ActionResult<int> DeleteAssignment(int id){
        //this needs to be ran after an end date of a students class
        //use the course id to delete the course along with assignmen
        //should also use student id so it doesnt delete other students stuff

        return 0;
    }

    [HttpPost]
    [Route("GetAssignment")]
    public ActionResult<Assignment> GetAssignment(int id){
        return new Assignment();
    }

    [HttpGet]
    [Route("GetCourses")]
    public ActionResult<Course[]> GetCourses(){
        return null;
    }

    [HttpGet]
    [Route("GetCourse")]
    public ActionResult<Course[]> GetCourse(int id){
        return null;
    }

    [HttpDelete]
    [Route("GetCourse")]
    public ActionResult<int> DeleteCourse(int id){
        return 0;
    }


}