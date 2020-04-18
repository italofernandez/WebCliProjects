import { AntivirusInfo } from './value-objects/antivirus-info.model';
import { HardDriveInfos } from './value-objects/hard-drive-infos.models';

export class Machine {
    id: number;
    machineName: string;
    localAddress: string;
    windowsVersion?: string;
    runtimeVersion?: string;

    antivirusInfo?: AntivirusInfo;
    hardDriveInfos?: HardDriveInfos[];
}