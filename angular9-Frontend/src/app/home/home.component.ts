import { CompileShallowModuleMetadata } from '@angular/compiler';

import { User } from '@app/_models';

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService, AlertService } from '@app/_services';


@Component({ templateUrl: 'home.component.html'})
              
export class HomeComponent implements OnInit {

    form: FormGroup;
     user: User;
     loading = false;
     submitted = false;
     // saldo2= new FormControl('');
     saldo2: number;
    
     

     
    constructor(private accountService: AccountService,
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private alertService: AlertService
    ) {

        this.user = this.accountService.userValue;
        this.saldo2 =  Number(this.user.saldo);
      
        

     }
     ngOnInit() {
        this.form = this.formBuilder.group ({
            
            saldo: ['', Validators.required],
            
        });
        
    }
    get f() { return this.form.controls; }
 
    onSubmit() {
        
        this.submitted = true;
        // reset alerts on submit
        this.alertService.clear();
        
        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        this.accountService.updateSaldo (this.user.id, this.form.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deposito Exitoso',{ keepAfterRouteChange: true });
                    
                    this.router.navigate(['/account']);
                    
                    
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
                
    /* this.loading = true;
    this.accountService.updateSaldo2 (this.user.id, this.saldo2.value)
        .pipe(first())
        .subscribe(
            data => {
                this.alertService.success('Extracción Exitosa',{ keepAfterRouteChange: true });
                
                this.router.navigate(['/account']);
                
                
            },
            error => {
                this.alertService.error(error);
                this.loading = false;
            }); */
            
}
}
    /*suma(x:number): number {
        this.miarray.push(x);
        let total = this.miarray.reduce((a, b) => a + b, 0);
        return total;
    }*/
   


    
   
