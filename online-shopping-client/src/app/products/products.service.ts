import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Product } from '../shared/models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() {}

  getProducts(): Observable<Product[]> {
    const mockedProducts: Product[] = [
      { id: 1, name: 'Product 1', description: 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Adipisci, modi earum. Ipsam enim architecto facere quis facilis deleniti, ex magni eligendi neque aliquid voluptate adipisci magnam rerum ducimus accusamus unde?', price: 10 },
      { id: 2, name: 'Product 2', description: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Est aspernatur ut incidunt debitis iste maiores optio eaque voluptates doloribus eveniet quaerat voluptatem perspiciatis nostrum ducimus non, tenetur, aliquam aperiam? Beatae.', price: 20 },
      { id: 3, name: 'Product 3', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque quae sint quo odio eveniet ipsa. Ut numquam, ad sed corporis, illum asperiores qui sit repellat, neque ea consectetur culpa velit?', price: 30 },
      { id: 4, name: 'Product 4', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Hic veritatis, impedit nesciunt possimus sequi aliquid velit maiores qui omnis quisquam officia modi! Cupiditate nisi laboriosam pariatur eius fugiat eligendi rem!', price: 40 },
      { id: 5, name: 'Product 5', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Excepturi deserunt tempore quam. Qui, fugit porro ipsum blanditiis quidem a eveniet nobis quod, autem magnam, doloremque itaque dolores laborum sint impedit?', price: 50 },
      { id: 6, name: 'Product 6', description: 'Lorem adipisicing elit. Excepturi deserunt tempore quam. Qui, fugit porro ipsum blanditiis quidem a eveniet nobis quod, autem magnam, doloremque', price: 50 }
    ];
    return of(mockedProducts)
  }
}
