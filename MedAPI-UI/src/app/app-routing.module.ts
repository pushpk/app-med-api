import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthModule } from './auth/auth.module';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '', loadChildren: () => import('../app/components/main/main.module').then(m => m.MainModule) },
  { path: 'login', loadChildren: () => import('../app/components/user/user.module').then(m => m.UserModule) },
  //{ path: '**', redirectTo: 'login', data: { isRedirect: true } }
 ];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    AuthModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
