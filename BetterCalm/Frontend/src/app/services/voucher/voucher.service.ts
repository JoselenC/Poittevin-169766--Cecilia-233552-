import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {Voucher} from '../../models/Voucher';
import {HttpClient} from '@angular/common/http';
import {Playlist} from '../../models/Playlist';
import {Status} from '../../models/Status';

@Injectable({
  providedIn: 'root'
})
export class VoucherService {
  private uri = '/api/voucher';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Voucher[]> {
    return this.http.get<Voucher[]>(this.uri);
  }

  approve(voucher: Voucher): Observable<Voucher> {
    voucher.status = Status.Approved;
    return this.http.put<Voucher>(this.uri + '/' + voucher.voucherId, voucher);
  }

  reject(voucher: Voucher): Observable<Voucher> {
    voucher.status = Status.Rejected;
    return this.http.put<Voucher>(this.uri + '/' + voucher.voucherId, voucher);
  }
}
