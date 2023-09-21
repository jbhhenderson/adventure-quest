public class Hat 
{
    public int ShininessLevel { get; set; }
    public string ShininessDescription {
        get {
            string text = "";

            if (ShininessLevel < 2)
            {
                text = "dull";
            }
            else if (ShininessLevel >= 2 && ShininessLevel <= 5)
            {
                text = "noticiable";
            }
            else if (ShininessLevel >= 6 && ShininessLevel <= 9)
            {
                text = "bright";
            }
            else if (ShininessLevel > 9)
            {
                text = "blinding";
            }
            return text;
        }
    }
}