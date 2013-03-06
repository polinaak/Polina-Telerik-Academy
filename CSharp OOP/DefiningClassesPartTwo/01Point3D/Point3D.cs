public struct Point3D
{
    //Fields
    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }

    public static readonly Point3D pointZero = new Point3D(0, 0, 0);

    //Constructors
    public Point3D(int x, int y, int z)
        :this()
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString()
    {
        return string.Format("The 3D point has coordinates: ({0}, {1}, {2})", this.x, this.y, this.z);
    }
}