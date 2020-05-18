import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommonModule } from '@angular/common';
// import { JwtModule, JwtInterceptor } from '@auth0/angular-jwt';
import { AuthGuardService } from './auth-guard.service';
import { UnauthGuard } from './unauth.guard';
//import { UserAuthService } from './user-auth.service';
// import { AuthTokenInterceptor } from './auth-token.interceptor';

export function getToken() {
    let storedData: string = localStorage.getItem('token');   
    return storedData;
}

// JwtModule.forRoot({
//             config: {
//                 tokenGetter: getToken,
//                 headerName: 'Authorization',
//                 authScheme: 'Bearer ',
//                 whitelistedDomains: [environment.whitelist]
//             }
//         })
@NgModule({
    imports: [
        CommonModule,
        HttpClientModule        
    ],
    declarations: [],
    providers: [
        AuthGuardService,
        UnauthGuard,
        //UserAuthService,
        //{
        //    provide: HTTP_INTERCEPTORS,
        //    useClass: AuthTokenInterceptor,
        //    multi: true
        //}
    ]
})
export class AuthModule { }
