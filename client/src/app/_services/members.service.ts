import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentProviders, inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_models/Member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  private http = inject(HttpClient);
  accountService = inject(AccountService);
  baseUrl = environment.baseUrl;

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  getMemberByUsername(username: string) {
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }
}
