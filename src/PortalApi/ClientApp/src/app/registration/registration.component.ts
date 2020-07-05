import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent {

    submitted: boolean = false;

    model = new RegistrationRequest("e", "e", "e", "e", "s");

    http: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.model = new RegistrationRequest("", "", "", "", "");
    }

    onSubmit() {
        this.submitted = true;
        this.http.post(this.baseUrl + 'registration', this.model, { responseType: 'json', observe: 'response' })
            .subscribe(res => {
                console.log(res);
                this.submitted = false;
                this.processResult(res);
            },
                err => {
                    console.log(err);
                    this.processResult(err);
                    this.submitted = false;
                });
    }

    processResult(response: HttpResponse<Object>) {
        try {
            switch (response.status) {
                case 202:
                    let jsonBody = JSON.parse(JSON.stringify(response.body));
                    alert(`Application registed. Application signature is ${jsonBody.message}`);
                    this.model = new RegistrationRequest("", "", "", "", "");
                    break;
                default:
                    alert("There was an error trying to register your application");
                    break;
            }
        }
        catch (ex) {
            alert("There was an error trying to register your application");
        }
        this.submitted = false;
    }

    get diagnostic() { return JSON.stringify(this.model); }

}

class RegistrationRequest {
    constructor(
        public companyName: string,
        public contactPerson: string,
        public email: string,
        public address: string,
        public licenseKey: string) { }
}
