namespace CanvasApi.Models
{
    
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using CanvasApi.Models;

public class Student{

    public int Id { get; set;}
    public string UserName { get; set;}

    public string Password { get; set;}

    public string ApiKey { get; set;}
    
    public string Email { get; set;}

    //will use only ids for this so that the student collection doesnt become jumbled
    public Assignment[] assignments { get; set; }

    public Course[] courses{ get; set;}

    public Student(int id, string userName, string password, string apiKey, string email, Assignment[] assignments, Course[] courses){
        this.Id = id;
        this.UserName = userName;
        this.Password = password;
        this.ApiKey = apiKey;
        this.Email = email;
        this.assignments = assignments;
        this.courses = courses;
    }

    public Student(){
        this.Id = 0;
        this.UserName = "";
        this.Password = "";
        this.ApiKey = "";
        this.Email = "";
        this.assignments = null;
        this.courses = null;
    }

    public void CreateStudent(Student student){

    }

    public void UpdateStudent(Student student, int studentId){

    }

    public void DeleteStudent(int id){

    }

    public Student GetStudent(int id){
        return null;
    }

    public Student[] GetStudents(){
        return null;
    }

    
}
}