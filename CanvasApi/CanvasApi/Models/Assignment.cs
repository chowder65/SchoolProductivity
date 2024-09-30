namespace CanvasApi.Models
{

public class Assignment{
    public int AssignmentId { get; set; }
    public string AssignmentName { get; set;}
    public string AssignmentDetails { get; set;}

    public string DueDate { get; set;}

    public int StudentId { get; set;}

    public int CourseId { get; set;}

    public void CreateAssignment(int AssignmentId, string AssignmentName, string AssignmentDetails, int StudentId, string DueDate, int CourseId){
        this.AssignmentId = AssignmentId;
        this.AssignmentName = AssignmentName;
        this.AssignmentDetails = AssignmentDetails;
        this.StudentId = StudentId;
        this.CourseId = CourseId;
    }

    public void CreateAssignment(){
        this.AssignmentId = 0;
        this.AssignmentName = "";
        this.AssignmentDetails = "";
        this.StudentId=0;
        this.CourseId=0;
    }

    public void UpdateAssignment(int AssignmentId, int StudentId){

    }

    public void DeleteAssignment(int AssignmentId){

    }

    public Assignment GetAssignment(int AssignmentId){
        return null;
    }

    public Assignment[] GetAssignments(){
        return null;
    }
    
}
}