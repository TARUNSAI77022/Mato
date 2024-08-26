using Microsoft.AspNetCore.Mvc;

namespace Mato.Service.WebApi.Controllers
{
    public class TestController5 : Controller
    {
        public IActionResult Index()
        {
            // Example array with 10 elements placed randomly
            int[] array = { 23, 45, 12, 78, 34, 56, 9, 67, 89, 11 };

            // Sort the array in descending order
            SortArrayDescending(array);

            // Return the sorted array as JSON
            return Json(array);
        }

        private void SortArrayDescending(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
