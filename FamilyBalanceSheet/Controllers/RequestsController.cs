// SPDX-FileCopyrightText: 2026 Tayra Sakurai
// 
// SPDX-License-Identifier: AGPL-3.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyBalanceSheet.Contexts;
using FamilyBalanceSheet.Models;

namespace FamilyBalanceSheet.Controllers
{
    public class RequestsController : Controller
    {
        private readonly FamilyBalanceSheetContext _context;

        public RequestsController(FamilyBalanceSheetContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated is not true)
                return Unauthorized();
            if (_context.Managers.ToList().Any(user => User.Identity!.Name == user.UserName))
                return View(await _context.Requests.ToListAsync());
            return BadRequest();
        }

        public IActionResult Create(string balance)
        {
            decimal balanceValue = 0;
            decimal.TryParse(balance, out balanceValue);
            Request rq = new()
            {
                Balance = balanceValue,
                UserName = User.Identity!.Name!,
            };
            return View(rq);
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,DateAndTime,Balance,IsAccepted")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(string? id)
        {
            if (!int.TryParse(id, out int inum)) return BadRequest();
            if (ItemExists(inum))
            {
                Request? rq = await _context.Requests.FindAsync(inum);
                if (rq == null) return BadRequest();
                rq.IsAccepted = true;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        public bool ItemExists(int id)
        {
            return _context.Requests.Any(i => i.Id == id);
        }

    }
}
