import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../services/api-service.service';
import { Router } from '@angular/router';
import { transactions } from '../models/transactions';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {
  lista: transactions[];
  transactions: transactions[];
  Id = '';
  FormaPagamento = '';
  StatusPagamento = '';
  ValorVenda = '';
  Referencia = '';
  DataPagamento = '';
  DataDeSolicitacao = '';
  AntiFraudRecommendation = '';
  CallbackUrl = '';
  NomeCliente = '';
  DocumentoCliente = '';
  EmailCliente = '';
  DocumentoEmpresa = '';
  IdMerchant = '';
  NomeEmpresa = '';
  NomeFantasia = '';
  Identity: string;
  Title = 'Listar Transações';
  txtBuscar = '';

  constructor(private provider: ApiServiceService, private router: Router) { }

  ngOnInit(): void {
    this.lista = [];
  }

  carregar(Identity: string){
    this.provider.getTransactions(this.Identity).subscribe(
    (_transactions: transactions[]) => {
        this.transactions = _transactions;
        this.lista = this.transactions;
        console.log(this.transactions);
       }, error => {
      //   this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
       });
  }

  mostrarTransacao(nomedaempresa: string, nomefantasia: string,
     nomecliente: string, id: string, antifraudrecommendation: string, callbackurl: string, documentocliente: string,
     emailcliente: string, documentoempresa: string, idmerchant: string){
    this.NomeFantasia = nomefantasia;
    this.NomeEmpresa = nomedaempresa;
    this.NomeCliente = nomecliente;
    this.Id = id;
    this.AntiFraudRecommendation = antifraudrecommendation;
    this.CallbackUrl = callbackurl;
    this.DocumentoCliente = documentocliente;
    this.EmailCliente = emailcliente;
    this.DocumentoEmpresa = documentoempresa;
    this.IdMerchant = idmerchant;
  }

}
