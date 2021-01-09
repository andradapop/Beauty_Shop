using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beauty_Shop.Data;

namespace Beauty_Shop.Models
{
    public class CategoriiProdusPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Beauty_ShopContext context, Produs produs)
        {
            var allCategories = context.Categorie; 
            var categoriiProdus = new HashSet<int>(
                produs.CategoriiProdus.Select(c => c.ProdusID)); 
            AssignedCategoryDataList = new List<AssignedCategoryData>(); 
            foreach (var cat in allCategories) 
            { 
                AssignedCategoryDataList.Add(new AssignedCategoryData 
                {
                    CategoryID = cat.ID, 
                    Name = cat.NumeCategorie, 
                    Assigned = categoriiProdus.Contains(cat.ID) 
                }); 
            }
        }

        public void UpdateProdusCategories(Beauty_ShopContext context, string[] selectedCategories, Produs produsToUpdate)
        {
            if(selectedCategories==null)
            {
                produsToUpdate.CategoriiProdus = new List<CategorieProdus>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriiProdus = new HashSet<int>
                (produsToUpdate.CategoriiProdus.Select(c => c.Categorie.ID));
            foreach(var cat in context.Categorie)
            {
                if(selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if(!categoriiProdus.Contains(cat.ID))
                    {
                        produsToUpdate.CategoriiProdus.Add(
                            new CategorieProdus
                            {
                                ProdusID = produsToUpdate.ID,
                                CategorieID = cat.ID
                            });
                    }
                }

                else
                {
                    if(categoriiProdus.Contains(cat.ID))
                    {
                        CategorieProdus coursetoRemove = produsToUpdate.CategoriiProdus.SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(coursetoRemove);
                    }
                }
            }
        }
    }
}
