﻿using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        // GET: Produtos
        public ActionResult BuscarPorNome(string nome)
        {
            nome = "Curso ASP .NET MVC5";
            
            var produtoViewModel2 = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.BuscarPorNome(nome));
            return View(produtoViewModel2);
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());
            return View(produtoViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }
        
            return View(produto);

        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            
            //ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), produto);
            //produto.ClienteId = ViewBag.ClienteId;,
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            produtoViewModel.ClienteList = ViewBag.ClienteId;
            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                
                ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);
            return RedirectToAction("Index");

        }
    }
}