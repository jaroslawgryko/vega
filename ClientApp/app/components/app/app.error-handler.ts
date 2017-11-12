import { ToastyService } from 'ng2-toasty';
import { ErrorHandler, Inject } from "@angular/core";


export class AppErrorHandler implements ErrorHandler {

    constructor(@Inject(ToastyService) private toastyService: ToastyService) {        
    }

    handleError(error: any): void {
        console.log("ERROR");

        this.toastyService.error ({
            title: 'Error',
            msg: 'Wystąpił nieoczekiwany błąd.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
        });
    }    
}