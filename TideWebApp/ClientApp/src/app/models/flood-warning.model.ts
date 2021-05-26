export class FloodWarning
{
    description: string;
    eaAreaName: string;
    message: string;
    severity: string;
    severityLevel: number;
    floodArea: FloodArea;
}

export class FloodArea
{
    county: string;
    riverOrSea: string;
}