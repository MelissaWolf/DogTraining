﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogTraining.Data;
using DogTraining.Training;

namespace DogTraining.Pages.DogPage
{
    public class CreateModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public CreateModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dog.Add(Dog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
