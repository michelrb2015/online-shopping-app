import { createAction, props } from '@ngrx/store';

export const login = createAction('[Auth] Login', props<{ username: string, password: string }>());
export const loginSuccess = createAction('[Auth] Login Success', props<{ userId: number }>());
export const loginFailure = createAction('[Auth] Login Failure', props<{ error: any }>());
export const logout = createAction('[Auth] Logout');

export const register = createAction('[Auth] Register', props<{ username: string, email: string, password: string }>());
export const registerSuccess = createAction('[Auth] Register Success');
export const registerFailure = createAction('[Auth] Register Failure', props<{ error: any }>());
