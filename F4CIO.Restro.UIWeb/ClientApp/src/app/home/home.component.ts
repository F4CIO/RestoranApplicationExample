import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public orders: OrderDetails[];
  model = new OrderDetails(new Date().toDateString(), "processing", '');
  msg = "";
  backendUrl = 'https://localhost:44302/';/*this.baseUrl +*/

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  ngOnInit() {
    this.getData();
  }
  getData() {
    this.http.get<OrderDetails[]>(this.backendUrl+'api/order').subscribe(result => {
      this.orders = result;
    }, error => console.error(error)); 
  }
  onSubmit() {
    this.msg = "Order added successfully";
    let t = {
     date: this.model.date,
     status: this.model.status,
     summary: this.model.summary
    };
    //this.orders.push(t);// = t;
    this.http.post(this.backendUrl+'api/order', t).subscribe(result => {
    //  console.log(result);
      this.getData();
    }, error => console.error(error));

  

  }
}


class OrderDetails {
  constructor(
    public date: string,
    public status: string,
    public summary: string,
  ) {}
}
