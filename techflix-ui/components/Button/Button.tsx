import React, {FunctionComponent} from "react";
import styles from "./Button.module.scss";
import Link from "next/link";

interface LinkButtonProps {
    href: string;
    testId: string;
}

export const PrimaryButtonLink: FunctionComponent<LinkButtonProps> = ({href, testId, children}) => {
    return (
        <Link href={href}>
            <a data-test-id={testId} className={styles.primaryButton}>
                {children}
            </a>
        </Link>
    );
};

export const SecondaryButtonLink: FunctionComponent<LinkButtonProps> = ({href, testId, children}) => {
    return (
        <Link href={href}>
            <a data-test-id={testId} className={styles.secondaryButton}>
                {children}
            </a>
        </Link>
    );    
};
