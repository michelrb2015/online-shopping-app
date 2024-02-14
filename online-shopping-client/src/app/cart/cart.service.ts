import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { Product } from '../shared/models/product.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItemsSubject: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>([]);
  public cartItems$: Observable<Product[]> = this.cartItemsSubject.asObservable();

  constructor() { }

  addToCart(product: Product): Observable<any> {
    const currentCartItems = this.cartItemsSubject.getValue();
    const updatedCartItems = [...currentCartItems, product];
    this.cartItemsSubject.next(updatedCartItems);
    return of(null);

  }

  removeFromCart(productId: number): Observable<any> {
    const currentCartItems = this.cartItemsSubject.getValue();
    const updatedCartItems = currentCartItems.filter(item => item.id !== productId);
    this.cartItemsSubject.next(updatedCartItems);
    return of(null);

  }

  getCartItems(userId: number): Observable<Product[]> {
    const mockedProducts: Product[] = [
      { id: 1, name: 'Product 1', description: 'Lorem ipsum, dolor sit amet consectetur adipisicing elit. Adipisci, modi earum. Ipsam enim architecto facere quis facilis deleniti, ex magni eligendi neque aliquid voluptate adipisci magnam rerum ducimus accusamus unde?', price: 10, quantity: 1 },
      { id: 3, name: 'Product 3', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloremque quae sint quo odio eveniet ipsa. Ut numquam, ad sed corporis, illum asperiores qui sit repellat, neque ea consectetur culpa velit?', price: 30, quantity: 2 },
      { id: 4, name: 'Product 4', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Hic veritatis, impedit nesciunt possimus sequi aliquid velit maiores qui omnis quisquam officia modi! Cupiditate nisi laboriosam pariatur eius fugiat eligendi rem!', price: 40, quantity: 1 },
      { id: 6, name: 'Product 6', description: 'Lorem adipisicing elit. Excepturi deserunt tempore quam. Qui, fugit porro ipsum blanditiis quidem a eveniet nobis quod, autem magnam, doloremque', price: 50 }
    ];
    return of(mockedProducts)
  }
}
