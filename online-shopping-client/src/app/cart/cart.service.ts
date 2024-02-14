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
}
