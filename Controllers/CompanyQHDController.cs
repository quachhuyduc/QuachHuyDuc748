using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuachHuyDuc748.Models;
using Microsoft.EntityFrameworkCore;
using QuachHuyDuc748.Data;


namespace QuachHuyDuc748.Controllers;

public class CompanyQHDController : Controller
{
    private readonly ApplicationDbContext _context;

    public CompanyQHDController (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var model = await _context.Companies.ToListAsync();
        return View(model);
    }
       public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CompanyQHD748 comp){
          if(ModelState.IsValid){
            _context.Add(comp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          }
          return View(comp);
    }
    private bool CompanyQHD748Exists(String id)
    {
        return _context.Companies.Any(e => e.CompanyId == id);
    }
    public async Task<IActionResult> Update (String id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var company = await _context.Companies.FindAsync(id);
        if(company == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(company);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(string id, [Bind("CompanyId,CompanyName")] CompanyQHD748 comp)
    {
          if(id != comp.CompanyId)
          {
            //return NotFound();
            return View("NotFound");
          }
          if (ModelState.IsValid)
          {
            try 
            {
                _context.Update(comp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CompanyQHD748Exists(comp.CompanyId))
                {
                    //return NotFound();
                    return View("NotFound");
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
          }
          return View(comp);
    }
     public async Task<IActionResult> Delete(string id)
    {
        if(id == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        var comp = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyId == id);
        if(comp == null)
        {
            //return NotFound();
            return View("NotFound");
        }
        return View(comp);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(string id)
     {
        var comp = await _context.Companies.FindAsync(id);
        _context.Companies.Remove(comp);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

     }
  


}
