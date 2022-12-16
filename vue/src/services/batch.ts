import axios from 'axios';
import { BASE_URL } from '@/utils/config';

export interface Batch {
  batchId: number;
  startTs: Date;
  endTs: Date;
  note?: string;
}

const baseUrl: string = 'http://localhost:5000/api';
const batchesUrl = `${baseUrl}/Batches`;
const getAll = () => axios.get<Batch[]>(batchesUrl);

export default { getAll };
