using System.ComponentModel;
using System.IO;
using System.IO.Enumeration;
using System.Text;



class Foo
{
    public static List<Circle> listCircle = new List<Circle>();
    public static List<EquilateralTriangle> listET = new List<EquilateralTriangle>();
    public static List<Square> listSquare = new List<Square>();
    public static List<Ellipse> ListEllipses = new List<Ellipse>();
    public static List<Polygon> listPolygon = new List<Polygon>();
    static void circle(string line)
    {
        var values = line.Split(',');
        Circle Temp = new Circle();
        Temp.Id = values[0];
        Temp.Name = values[1];
        Temp.CenterX = values[3];
        Temp.CenterY = values[5];
        Temp.Radius = values[7];
        double temp_radius = Convert.ToDouble(Temp.Radius);
        Temp.Perimeter = Convert.ToString(2 * 3.14 *temp_radius);
        Temp.Area = Convert.ToString(3.14 *temp_radius*temp_radius);
        listCircle.Add(Temp);
    }

    static void equilateralTriangle(string line)
    {
        var values = line.Split(',');
        EquilateralTriangle Temp = new EquilateralTriangle();
        Temp.Id = values[0];
        Temp.Name = values[1];
        Temp.CenterX = values[3];
        Temp.CenterY = values[5];
        Temp.SideLength = values[7];
        Temp.Orienation = values[9];
        double temp_SideL = Convert.ToDouble(Temp.SideLength);
        Temp.Perimeter = Convert.ToString(3 * temp_SideL);
        Temp.Area = Convert.ToString((Math.Sqrt(3) / 4) * (temp_SideL * temp_SideL));
        listET.Add(Temp);
    }

    static void square(string line)
    {
        var values = line.Split(',');
        Square Temp = new Square();
        Temp.Id = values[0];
        Temp.Name = values[1];
        Temp.CenterX = values[3];
        Temp.CenterY = values[5];
        Temp.SideLength = values[7];
        Temp.Orienation = values[9];
        double temp_SideL = Convert.ToDouble(Temp.SideLength);
        Temp.Perimeter = Convert.ToString(4 * temp_SideL);
        Temp.Area = Convert.ToString(temp_SideL * temp_SideL);
        listSquare.Add(Temp);
        
    }

    static void ellipse(string line)
    {
        var values = line.Split(',');
        Ellipse Temp = new Ellipse();
        Temp.Id = values[0];
        Temp.Name = values[1];
        Temp.CenterX = values[3];
        Temp.CenterY = values[5];
        Temp.R1 = values[7];
        Temp.R2 = values[9];
        
        Temp.Orienation = values[11];
        double temp_r1 = Convert.ToDouble(Temp.R1);
        double temp_r2 = Convert.ToDouble(Temp.R2);
        
        Temp.Perimeter = Convert.ToString(3.14*Math.Sqrt((temp_r1*temp_r1)+(temp_r2*temp_r2)));
        Temp.Area = Convert.ToString(3.14*temp_r1*temp_r2);
        ListEllipses.Add(Temp);
    }
    
    
    static void polygon(string line)
    {
        var values = line.Split(',');
        Polygon Temp = new Polygon();
        Temp.Id = values[0];
        Temp.Name = values[1];
        int i = 3;
        
        while (i < values.Length)
        {
            Temp.X.Add(values[i]);
            Temp.Y.Add(values[i+2]);
            i = i + 4;
        }

        double sumP = 0;
        double sumN = 0;
        ;
        double sumPerimeter = 0;
        for (i = 0; i < Temp.X.Count-1;i++)
        {
            double tempX1 = Convert.ToDouble(Temp.X[i]);
            double tempX2 = Convert.ToDouble(Temp.X[i + 1]);
            double tempY1 = Convert.ToDouble(Temp.Y[i]);
            double tempY2 = Convert.ToDouble(Temp.Y[i + 1]);
            sumP += (tempX1 * tempY2);
            sumN += (tempX2 * tempY1);
            sumPerimeter +=
                Math.Sqrt(((tempX2 - tempX1) * (tempX2 - tempY1)) + ((tempY2 - tempY1) * (tempY2 - tempY1)));
        }
        i = Temp.X.Count - 1;
        double tempX11 = Convert.ToDouble(Temp.X[i]);
        double tempX21 = Convert.ToDouble(Temp.X[0]);
        double tempY11 = Convert.ToDouble(Temp.Y[i]);
        double tempY21 = Convert.ToDouble(Temp.Y[0]);
        
        sumP+=(tempX11 * tempY21);
        sumN += (tempX21 * tempY11);
        sumPerimeter +=
            Math.Sqrt(((tempX21 - tempX11) * (tempX21 - tempY11)) + ((tempY21 - tempY11) * (tempY21 - tempY11)));
        double temp_area = (sumN - sumP) / 2;
        
        
        Temp.Perimeter = Convert.ToString(sumPerimeter);
        Temp.Area = Convert.ToString(temp_area);
        listPolygon.Add(Temp);
    }

    static void writeFile()
    {
        string FileName = "output.csv";
        
        File.WriteAllText(FileName,"");
        int i = 0;
        
        for (i = 0; i < listCircle.Count; i++)
        {
            string line=listCircle[i].Id+","+listCircle[i].Name+",CenterX,"+listCircle[i].CenterX+",CenterY,"+listCircle[i].CenterY+",Radius,"+listCircle[i].Radius+",Area,"+listCircle[i].Area+",Perimeter,"+listCircle[i].Perimeter;
            
            File.AppendAllText(FileName, line+Environment.NewLine);
        }
        
        for (i = 0; i < listSquare.Count; i++)
        {
            string line=listSquare[i].Id+","+listSquare[i].Name+",CenterX,"+listSquare[i].CenterX+",CenterY,"+listSquare[i].CenterY+",Side Length,"+listSquare[i].SideLength+",Orienation,"+listSquare[i].Orienation+",Area,"+listSquare[i].Area+",Perimeter,"+listSquare[i].Perimeter;
            
            File.AppendAllText(FileName, line+Environment.NewLine);
        }
        for (i = 0; i < listET.Count; i++)
        {
            string line=listET[i].Id+","+listET[i].Name+",CenterX,"+listET[i].CenterX+",CenterY,"+listET[i].CenterY+",Side Length,"+listET[i].SideLength+",Orienation,"+listET[i].Orienation+",Area,"+listET[i].Area+",Perimeter,"+listET[i].Perimeter;
            
            File.AppendAllText(FileName, line+Environment.NewLine);
        }
        for (i = 0; i < ListEllipses.Count; i++)
        {
            string line=ListEllipses[i].Id+","+ListEllipses[i].Name+",CenterX,"+ListEllipses[i].CenterX+",CenterY,"+ListEllipses[i].CenterY+",R1,"+ListEllipses[i].R1+",R2,"+ListEllipses[i].R2+",Orienation,"+ListEllipses[i].Orienation+",Area,"+ListEllipses[i].Area+",Perimeter,"+ListEllipses[i].Perimeter;
            
            File.AppendAllText(FileName, line+Environment.NewLine);
        }
        for (i = 0; i <listPolygon.Count; i++)
        {
            string line=listPolygon[i].Id+","+listPolygon[i].Name+",X,"+String.Join(',', listPolygon[i].X)+",Y,"+String.Join(',', listPolygon[i].X)+",Area,"+listPolygon[i].Area+",Perimeter,"+listPolygon[i].Perimeter;
            
            File.AppendAllText(FileName, line+Environment.NewLine);
        }
        
            
    }

    
    static void Main(string[] args)
    {
        
        List<string> listB = new List<string>();
        using(var reader = new StreamReader(@"C:\Users\Shreeni\Downloads\Machine Vision Development Engineer Coding Exercise _ ShapeList2.csv"))
        {
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values[1] == "Circle")
                {
                    circle(line);
                }
                else if (values[1] == "Equilateral Triangle")
                {
                    equilateralTriangle(line);
                }
                else if (values[1] == "Square")
                {
                    square(line);
                }
                else if (values[1] == "Ellipse")
                {
                    ellipse(line);
                }
                else if (values[1] == "Polygon")
                {
                    polygon(line);
                }

            }
            writeFile();
            
        }

        
    }
    
}



class Circle
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string  CenterX { get; set; }
    public string  CenterY { get; set; }
    public string Radius { set; get; }
    public string Area { get; set; }
    public string Perimeter { set; get; }
}

class EquilateralTriangle
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string  CenterX { get; set; }
    public string  CenterY { get; set; }
    public string SideLength { set; get; }
    public string Orienation { get; set; }
    public string Area { get; set; }
    public string Perimeter { set; get; }
}

class Square
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string  CenterX { get; set; }
    public string  CenterY { get; set; }
    public string SideLength { set; get; }
    public string Orienation { get; set; }
    public string Area { get; set; }
    public string Perimeter { set; get; }
}

class Ellipse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string  CenterX { get; set; }
    public string  CenterY { get; set; }
    public string R1 { set; get; }
    public string R2 { get; set; }
    public string Orienation { get; set; }
    public string Area { get; set; }
    public string Perimeter { set; get; }
}


class Polygon
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> X { get; set; } = new List<string>();
    
    public List<string> Y { get; set; } = new List<string>();
    
    public string Area { get; set; }
    public string Perimeter { set; get; }
}