using UnityEngine;

/// <summary>
/// placed on list of all courses
/// manages singleCourse component
/// creates rows and tiles on demand
/// </summary>

public class CourseManager : MonoBehaviour {

    public RectTransform currentRow; // for the sake of simplicity and to save my time I will assume that there is one already existing
    public singleCourse course;
    public RectTransform courseClone;
    public RectTransform coursePrefarb;
    public RectTransform rowPrefarb;
    public RectTransform content;

    public int maxChild = 4;

    //add no courses alert here, later on
    //called only to create new course 
    public void handleContent(string title, Texture tex = null)
    {
        if(checkIfFull())
        {
          //create row and the first course
            currentRow = Instantiate(rowPrefarb, content);
            currentRow.transform.localScale = new Vector3(1, 1, 1);

            courseClone = Instantiate(coursePrefarb, currentRow);
            courseClone.transform.localScale = new Vector3(0.95f, 1, 1);
            //handle it
            handleCourse(title, tex);
        }
        else
        {
            courseClone = Instantiate(coursePrefarb, currentRow);
            courseClone.transform.localScale = new Vector3(0.95f, 1, 1);
            handleCourse(title, tex);
        }
    }
    public void hasContent()
    {
        //nothing yet
    }
    public bool checkIfFull()
    {
        if (currentRow.childCount == maxChild)
            return true;
        return false;
    }

    private void handleCourse(string title, Texture tex = null)
    {
        //grab singleCours component from current course object
        course = courseClone.GetComponent<singleCourse>();
        course.setTitle(title);
        course.setBackground(tex);
    }
}
