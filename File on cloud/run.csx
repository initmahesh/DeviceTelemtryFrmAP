public static void Run(Stream myBlob, string name, TraceWriter log, ICollector<AccessPoint> outputTable)
//public static void Run(Stream myBlob, string name, TraceWriter log)
{
    log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
       int count =0;
       //DateTime today = DateTime.UtcNow.Date;
        DateTime _now = DateTime.Now;
        string _dd = _now.ToString("dd"); //
        string _mm = _now.ToString("MM");
        string _yy = _now.ToString("yyyy");
        string _hh = _now.Hour.ToString();
        string _min = _now.Minute.ToString();
        string _ss = _now.Second.ToString();

        string _uniqueId= _dd+ _hh+ _mm+_min+_ss + _yy;
           log.Info(_uniqueId);
        using (StreamReader reader = new StreamReader(myBlob))
        {
            while(!reader.EndOfStream)
            {

                log.Info(reader.ReadLine());
                count++;
            }
            log.Info("No fo connected devices are :: "+ count);
        }
        outputTable.Add(
            new AccessPoint(){
                //PartitionKey = ""+ Math.Floor(int(DateTime.Today)/24*60*60*1000),
                PartitionKey = "Redmond,WA,USA" ,
                RowKey = _uniqueId,
                NoOfActiveDevices = count} 

                
        ); 
        log.Info("!!!!!!UPdated tracking table !!!!!!!");
}

public class AccessPoint
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public int NoOfActiveDevices {get; set;}
}
