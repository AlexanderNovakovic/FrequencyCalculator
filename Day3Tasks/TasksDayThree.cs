namespace Day3Tasks
{
    public static class TasksDayThree
    {
        public static int CalculateOverlappingSurface(string[] fileText)
        {
            int overlappingSurface = 0;            
            
            int[][] totalSurface = FillTotalSurfaceWithZeros(1000);

            MakeAllClaims(fileText, totalSurface);
            
            for (int i = 0; i < totalSurface.Length; i++)
            {                
                for (int j = 0; j < totalSurface[i].Length; j++)
                {
                    if (totalSurface[i][j] > 1)
                    {
                        overlappingSurface++;
                    }
                }
            }

            return overlappingSurface;
        }

        public static int FindNonOverlappingClaimId(string[] fileText)
        {
            int[][] totalSurface = FillTotalSurfaceWithZeros(1000);

            MakeAllClaims(fileText, totalSurface);

            foreach (string line in fileText)
            {
                Claim claim = ReadClaimFromString(line);

                if (!IsOverlapping(claim, totalSurface))
                    return claim.Id;
            }

            return 0;            
        }

        public static bool IsOverlapping(Claim claim, int[][] totalSurface)
        {
            for (int i = claim.Rectangle.TopLeftX; i < claim.Rectangle.TopLeftX + claim.Rectangle.Width; i++)
            {
                for(int j = claim.Rectangle.TopLeftY; j < claim.Rectangle.TopLeftY + claim.Rectangle.Height; j++)
                {
                    if(totalSurface[i][j] > 1)
                        return true;
                }
            }

            return false;
        }

        public static void MakeAllClaims(string[] input, int[][] surface)
        {
            foreach (string line in input)
            {
                Claim claim = ReadClaimFromString(line);

                MakeClaim(surface, claim);
            }
        }

        public static void MakeClaim(int[][] surface, Claim claim)
        {
            for (int i = claim.Rectangle.TopLeftX; i < claim.Rectangle.TopLeftX + claim.Rectangle.Width; i++)
            {
                for (int j = claim.Rectangle.TopLeftY; j < claim.Rectangle.TopLeftY + claim.Rectangle.Height; j++)
                {
                    surface[i][j]++;
                }
            }
        }

        public static int[][] FillTotalSurfaceWithZeros(int size)
        {
            int[][] totalSurface = new int[size][];

            for (int i = 0; i < totalSurface.Length; i++)
            {
                totalSurface[i] = new int[size];
                for (int j = 0; j < totalSurface[i].Length; j++)
                {
                    totalSurface[i][j] = 0;
                }
            }

            return totalSurface;
        }

        public static Claim ReadClaimFromString(string line)
        {
            int id = ReturnIdFrom(line);
            int topLeftX = ReturnTopLeftXFrom(line);
            int topLeftY = ReturnTopLeftYFrom(line);
            int width = ReturnWidthFrom(line);
            int height = ReturnHeightFrom(line);

            Rectangle rectangle = new Rectangle(topLeftX, topLeftY, width, height);

            Claim claim = new Claim(id, rectangle);

            return claim;
        }

        public static int ReturnIdFrom(string line)
        {
            string[] lineSplit = line.Split('@');

            int idElement = int.Parse(lineSplit[0].Substring(1).Trim());

            return idElement;
        }
        
        public static int ReturnTopLeftXFrom(string line)
        {
            string[] lineSplit = line.Split('@');

            string lineTwo = lineSplit[1];

            string[] lineTwoSplit = lineTwo.Split(':');

            string lineThree = lineTwoSplit[0];

            string[] lineFour = lineThree.Split(',');

            return int.Parse(lineFour[0].Trim());
        }
        
        public static int ReturnTopLeftYFrom(string line) => int.Parse(line.Split('@')[1].Split(':')[0].Split(',')[1]);

        public static int ReturnWidthFrom(string line) => int.Parse(line.Split('@')[1].Split(':')[1].Split('x')[0].Trim());
        
        public static int ReturnHeightFrom(string line) => int.Parse(line.Split('@')[1].Split(':')[1].Split('x')[1]);
    }
}
