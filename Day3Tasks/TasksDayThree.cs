using System.Collections.Generic;
using static FileExtensions.FileExtensions;

namespace Day3Tasks
{
    public static class TasksDayThree
    {
        public static int CalculateOverlappingSurface(Claim[] claims)
        {
            int overlappingSurface = 0;

            int[][] fabric = CreateFabric(1000);

            MakeClaims(fabric, claims);

            for (int i = 0; i < fabric.Length; i++)
            {
                for (int j = 0; j < fabric[i].Length; j++)
                {
                    if (fabric[i][j] > 1)
                    {
                        overlappingSurface++;
                    }
                }
            }

            return overlappingSurface;
        }

        public static int FindNonOverlappingClaimId(Claim[] claims)
        {
            int[][] totalSurface = CreateFabric(1000);

            MakeClaims(totalSurface, claims);

            foreach (Claim claim in claims)
            {
                if (!IsOverlapping(totalSurface, claim))
                    return claim.Id;
            }

            return 0;
        }

        private static int[][] CreateFabric(int size)
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

        private static void MakeClaims(int[][] fabric, Claim[] claims)
        {
            foreach (Claim claim in claims)
                MakeClaim(fabric, claim);
        }

        private static void MakeClaim(int[][] surface, Claim claim)
        {
            for (int i = claim.Rectangle.TopLeftX; i < claim.Rectangle.TopLeftX + claim.Rectangle.Width; i++)
            {
                for (int j = claim.Rectangle.TopLeftY; j < claim.Rectangle.TopLeftY + claim.Rectangle.Height; j++)
                {
                    surface[i][j]++;
                }
            }
        }

        public static Claim[] ReadClaimsFromFile(string filePath)
        {
            List<Claim> claims = new List<Claim>();

            foreach (string claimAsString in ReadStringArrayFromFile(filePath))
            {
                claims.Add(ParseClaim(claimAsString));
            }

            return claims.ToArray();
        }

        public static Claim ParseClaim(string line)
        {
            int id = ExtractId(line);
            int topLeftX = ExtractTopLeftX(line);
            int topLeftY = ExtractTopLeftY(line);
            int width = ExtractWidth(line);
            int height = ExtractHeight(line);

            Rectangle rectangle = new Rectangle(topLeftX, topLeftY, width, height);

            Claim claim = new Claim(id, rectangle);

            return claim;
        }

        private static int ExtractId(string line) => 
            int.Parse(line.Split('@')[0].Substring(1).Trim());

        private static int ExtractTopLeftX(string line) => 
            int.Parse(line.Split('@')[1].Split(':')[0].Split(',')[0].Trim());

        private static int ExtractTopLeftY(string line) =>
            int.Parse(line.Split('@')[1].Split(':')[0].Split(',')[1]);

        private static int ExtractWidth(string line) =>
            int.Parse(line.Split('@')[1].Split(':')[1].Split('x')[0].Trim());

        private static int ExtractHeight(string line) =>
            int.Parse(line.Split('@')[1].Split(':')[1].Split('x')[1]);

        private static bool IsOverlapping(int[][] totalSurface, Claim claim)
        {
            for (int i = claim.Rectangle.TopLeftX; i < claim.Rectangle.TopLeftX + claim.Rectangle.Width; i++)
            {
                for (int j = claim.Rectangle.TopLeftY; j < claim.Rectangle.TopLeftY + claim.Rectangle.Height; j++)
                {
                    if (totalSurface[i][j] > 1)
                        return true;
                }
            }

            return false;
        }
    }
}
