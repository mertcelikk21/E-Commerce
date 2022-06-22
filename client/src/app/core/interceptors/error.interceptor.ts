import {HttpEvent,HttpHandler,HttpInterceptor,HttpRequest,} from '@angular/common/http';
import { typeWithParameters } from '@angular/compiler/src/render3/util';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError, Observable, throwError } from 'rxjs';


@Injectable()
export class ErrorInterCeptor implements HttpInterceptor {
  constructor(private router: Router, private toastr : ToastrService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error) => {
        if(error){
              if(error.status === 400 ){
                if(error.error.errors){
                  throw error.error;
                }
                else{
                this.toastr.error(error.error.message,error.error.statuscode)
                }
              }
              if(error.status === 401 ){
                this.toastr.error(error.error.message,error.error.statuscode)
              }
              if (error.status === 404) {
                  this.router.navigateByUrl('/not-found');
                }
      
              if (error.status === 500) {
                this.router.navigateByUrl('/server-error');
              }
        }
        return throwError(error);
      })
    );
  }
}
