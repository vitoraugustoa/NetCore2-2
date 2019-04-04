import { Component, OnInit, OnDestroy } from '@angular/core';
import { ClienteService } from '../Services/cliente.service';
import { Cliente } from '../Models/Cliente';

@Component({
  selector: 'cliente-app',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})

export class ClienteComponent implements OnInit {
  cliente: Cliente;
  clientes: Cliente[];

  constructor(private clienteService: ClienteService) {}


  private getClientesById(id: number) {
    this.clienteService.getClienteById(id).subscribe(
      data => this.cliente = data,
      error => alert(error),
      () => console.log(this.cliente)
    );
  }


  private getClientes() {
    this.clienteService.getClientes().subscribe(
      data => this.clientes = data,
      error => alert(error),
      () => console.log(this.clientes)
    );
  }

  ngOnInit() {
    this.getClientes();
  }


}
